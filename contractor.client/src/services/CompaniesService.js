import { AppState } from "../AppState.js"
import { logger } from "../utils/logger.js"
import { api } from "./AxiosService.js"

class CompaniesService {
  async getCompanies() {
      const res = await api.get("api/companies");
      logger.log(res.data);
      AppState.companies = res.data;
;
   
  }
}

export const companiesService = new CompaniesService();
