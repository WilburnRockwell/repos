const Router = require('express');
const typeController = require('../controllers/typeController');
const router = new Router()
const roleCheck = require('../middleware/rolecheckMiddleware')

router.post('/', roleCheck('ADMIN'), typeController.create)
router.get('/', typeController.getAll)

module.exports = router;