<template>
  <div
    class="product p-2 selectable"
    :data-bs-target="inWarehouse ? '' : '#product-modal' + product.id"
    data-bs-toggle="modal"
  >
    {{ product.name }}
  </div>
  <div v-if="!inWarehouse">
    <Modal :id="'product-modal' + product.id" class="text-dark">
      <template #modal-header>{{ product.name }}></template>
      <template #modal-body>
        <h3>{{ product.description }}</h3>
        <p>{{ product.sku }}</p>
        <div>
          <title>add to warehouse</title>
          <select name="" id="" v-model="warehouseId">
            <option :value="w.id" v-for="w in warehouses" :key="w.id">
              {{ w.location }}
            </option>
          </select>
          <button class="btn btn-success" @click="addToWarehouse">+</button>
        </div>
      </template>
    </Modal>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from '../utils/Logger';
import { warehouseProductsService } from '../services/WarehouseProductsService';
export default {
  props: {
    product: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const warehouseId = ref('')
    return {
      warehouseId,
      warehouses: computed(() => AppState.warehouses),
      inWarehouse: computed(() => props.product.warehouseProductId != undefined),
      async addToWarehouse() {
        try {
          logger.log('adding', props.product.name, 'to warehouse', warehouseId.value)
          const newWarehouseProduct = { productId: props.product.id, warehouseId: warehouseId.value }
          logger.log('body', newWarehouseProduct)
          await warehouseProductsService.create(newWarehouseProduct)
        } catch (error) {
          logger.log(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
};
</script>


<style scoped>
</style>
