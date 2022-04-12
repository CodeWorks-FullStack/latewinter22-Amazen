<template>
  <div class="container-fluid">
    <h2>Warehouses</h2>
    <div class="row justify-content-center">
      <div
        class="col-12 col-md-8 p-3 border selectable"
        data-bs-target="#warehouse-modal"
        data-bs-toggle="modal"
        v-for="w in warehouses"
        :key="'warehouse-' + w.id"
        @click="setActive(w)"
      >
        <Warehouse :warehouse="w" />
      </div>
    </div>
    <h2>Products</h2>
    <div class="row justify-content-center bg-dark text-light">
      <div
        class="col-12 col-md-8 border border-primary"
        v-for="p in products"
        :key="p.id"
      >
        <Product :product="p" />
      </div>
    </div>
    <Modal id="warehouse-modal">
      <template #modal-header>{{ activeWarehouse.location }} details</template>
      <template #modal-body>
        <WarehouseDetails />
      </template>
    </Modal>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { productsService } from '../services/ProductsService'
import { warehousesService } from '../services/WarehousesService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await productsService.getAll()
        await warehousesService.getAll()
      } catch (error) {
        logger.log(error)
        Pop.toast(error.message, 'error')
      }
    })
    return {
      warehouses: computed(() => AppState.warehouses),
      activeWarehouse: computed(() => AppState.activeWarehouse),
      products: computed(() => AppState.products),
      async setActive(warehouse) {
        try {
          // NOTE should probably be the service but we are speed coding
          AppState.activeWarehouse = warehouse
          await warehousesService.getProducts(warehouse.id)
        } catch (error) {
          logger.log(error)
          Pop.toast(error.message, 'error')
        }

      }
    }
  }
}
</script>

<style scoped lang="scss">
</style>
