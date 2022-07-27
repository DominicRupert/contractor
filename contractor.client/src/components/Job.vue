<template>
  <div class="row">
    <div class="col-12 d-flex flex-row">
      <h1>
        {{ job.name }}
      </h1>
    </div>
  </div>
</template>


<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import { jobsService } from '../services/JobsService.js';
import Pop from '../utils/Pop.js';
export default {
  props: {
    job: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const companyId = ref(0)

    return {
      companyId,
      companies: computed(() => AppState.companies),

    }
  }
}
</script>


<style lang="scss" scoped>
</style>