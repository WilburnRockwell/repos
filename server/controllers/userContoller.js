const ApiError = require('../errors/apiError')
const bcrypt = require('bcrypt')
const jwt = require('jsonwebtoken')
const {
    User    
} = require('../models/models')

const genToken = (id, email, role) => {
    return jwt.sign({
        id,
        email,
        role
    }, process.env.SECRET_KEY, {
        expiresIn: '1h'
    })
}

class UserController {
    async registration(req, res) {
        const {
            email,
            password,
            role
        } = req.body
        if (!email) {
            return next(ApiError.badRequest('Вы где-то ошиблись!'))
        }
        const candidate = await User.findOne({
            where: {
                email
            }
        })
        if (candidate) {
            return res.status(400).json({message:"Пользователь с таким адресом уже существует"})
        }

        const hashPassword = await bcrypt.hash(password, 5)
        const user = await User.create({
            email,
            role,
            password: hashPassword
        })        
        const token = genToken(user.id, user.email, user.role)
        res.json({
            token
        })
    }

    async login(req, res, next) {
        const{email, password} = req.body
        const user = await User.findOne({where: {email}})
        if(!user){
            return next(ApiError.internal('Похоже, такого пользователя еще нет'))
        }
        let comparePassword = bcrypt.compareSync(password, user.password)
        if (!comparePassword){
            return next(ApiError.internal('А пароль то не подходит'))
        }
        const token = genToken(user.id, user.email, user.role)
        return res.json({token})
    }

    async checking(req, res, next) {
        const token = genToken(req.user.id, req.user.email, req.user.role)
        return res.json({token})
    }
}

module.exports = new UserController()