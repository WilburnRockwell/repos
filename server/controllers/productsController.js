const uuid = require('uuid')
const path = require('path')
const {
    Products, ProductsInfo
} = require('../models/models')
const ApiError = require('../errors/apiError')


class ProductsController {
    async create(req, res, next) {
        try {
            let {
                name,
                price,
                brandId,
                typeId,
                info
            } = req.body
            const {
                img
            } = req.files
            let fileName = uuid.v4() + ".jpg"
            img.mv(path.resolve(__dirname, '..', 'static', fileName))
  const products = await Products.create({
                name,
                price,
                brandId,
                typeId,
                img: fileName
            });

            if (info){
                info = JSON.parse(info)
                info.forEach(i => 
                    ProductsInfo.create({
                        title: i.title,
                        description: i.description,
                        productsId: products.id
                    })
                 )
            }
          

            return res.json(products)
        } catch (e) {
            next(ApiError.badRequest(e.message))
        }

    }

    async getAll(req, res) {
        let {
            brandId,
            typeId,
            limit, 
            page
        } = req.query
        page = page || 1
        limit = limit || 12
        let offset = page * limit - limit
        let products;

        if (!brandId && !typeId) {
            products = await Products.findAndCountAll({limit, offset})
        }

        if (brandId && !typeId) {
            products = await Products.findAndCountAll({where:{brandId}, limit, offset})
        }

        if (!brandId && typeId) {
            products = await Products.findAndCountAll({where:{typeId}, limit, offset})
        }

        if (brandId && typeId) {
            products = await Products.findAndCountAll({where:{brandId, typeId}, limit, offset})
        }

        return res.json(products)
    }

    async getOne(req, res) {
        const {id} = req.params
        const products = await Products.findOne(
        {
            where: {id},
            include: [{model: ProductsInfo, as: 'info'}]
        })
        return res.json(products)
    }
}

module.exports = new ProductsController()