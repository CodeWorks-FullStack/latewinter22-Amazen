import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class ProductsService {
  async getAll(){
    const res = await api.get('api/products')
    logger.log('[getAll products]', res.data)
    AppState.products = res.data
  }

}

export const productsService = new ProductsService()
