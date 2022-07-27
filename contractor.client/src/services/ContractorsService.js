import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"
import { logger } from "../utils/logger.js"


class ContractorsService {
    async getContractors() {
        const res = await api.get("api/contractors");
        logger.log(res.data);
        AppState.contractors = res.data;
    }
    }

    export const contractorsService = new ContractorsService();