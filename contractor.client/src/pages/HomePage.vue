<template>
<div class="container">
<Job v-for="j in jobs" :key="j.id" :job="j" />
<div class="row">
<div class="col-6">

  <h1 v-for="con in contractors" :key="con.id" >
    {{con.profession}}
    

</h1>
</div>
<div class="col-6">

  <h1 v-for="c in companies" :key="c.id">{{c.name}}</h1>
</div>
</div>
</div>
</template>

<script>
import {computed, onMounted, ref} from 'vue';
import { AppState } from '../AppState.js';
import { companiesService } from '../services/CompaniesService.js';
import { contractorsService } from '../services/ContractorsService.js';
import { jobsService } from '../services/JobsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup(){
    const activeJobId = ref(0)
    onMounted(async()=> {
      try{
        await companiesService.getCompanies();
        await contractorsService.getContractors();
        await jobsService.getJobs();

      }catch (e) {
        logger.error(e);
        Pop.error(e.message);
      }
    })
return {
  activeJobId,
  companies: computed(() => AppState.companies),
  contractors: computed(() => AppState.contractors),
  jobs: computed(() => AppState.jobs),
  async setActiveJob(){
    try{
      await jobsService.getByCompanyId(activeJobId.value);
    }catch (e) {
      logger.error(e);
      Pop.error(e.message);
    }
  }
}
  }
  
}
</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
