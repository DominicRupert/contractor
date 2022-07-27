import { AppState } from "/AppState.js";
import { logger } from "./logger.js";
import { api } from "./AxiosService.js";

class JobsService {
  async getJobs() {
    const res = await api.get("api/jobs");
    logger.log(res.data);
    AppState.jobs = res.data;
  }

  async getByCompanyId(id) {
    const res = await api.get(`api/companies/${id}/jobs`);
    logger.log(res.data);
    AppState.jobs = res.data;
  }
}

export const jobsService = new JobsService();
