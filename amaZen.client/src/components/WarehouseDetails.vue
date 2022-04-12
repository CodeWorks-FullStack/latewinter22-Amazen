<template>
  <div class="warehouse-details container-fluid">
    <div class="row">
      <div v-for="p in products" :key="'product-' + p.id" class="col-12">
        <Product :product="p" />
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  setup() {
    return {
      products: computed(() => AppState.activeWarehouseProducts)
    }
  }
};
</script>


<style scoped>
</style>
