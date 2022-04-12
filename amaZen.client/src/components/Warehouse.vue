<template>
  <div class="warehouse row">{{ warehouse.location }}</div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: {
    warehouse: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
};
</script>


<style scoped>
</style>
