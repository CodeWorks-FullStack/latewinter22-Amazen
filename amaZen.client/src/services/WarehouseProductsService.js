import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class WarehouseProductsService {
async create(newData){
  const res = await api.post('api/warehouseproducts', newData)
  logger.log('[created new WarehouseProduct]', res.data)
}
}

export const warehouseProductsService = new WarehouseProductsService()
