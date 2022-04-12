import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class WarehousesService {

  async getAll(){
    const res = await api.get('api/warehouses')
    logger.log('[getAll warehouses]', res.data)
    AppState.warehouses = res.data
  }

  async getProducts(id){
    const res = await api.get(`api/warehouses/${id}/products`)
    logger.log('[getProducts]', res.data)
    AppState.activeWarehouseProducts = res.data
  }
}

export const warehousesService = new WarehousesService()
