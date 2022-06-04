const Router = require('express');
const brandController = require('../controllers/brandController');
const router = new Router()
const roleCheck = require('../middleware/rolecheckMiddleware')


router.post('/', roleCheck('ADMIN'), brandController.create)
router.get('/', brandController.getAll)

module.exports = router;