const Router = require('express')
const router = new Router()
const productsController = require('../controllers/productsController')
const roleCheck = require('../middleware/rolecheckMiddleware')

router.post('/', roleCheck('ADMIN'), productsController.create)
router.get('/', productsController.getAll)
router.get('/: id', productsController.getOne)

module.exports = router;