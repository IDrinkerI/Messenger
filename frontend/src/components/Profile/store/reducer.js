import { CHANGE_PROFILE, INIT_PROFILE } from "./types";


const initialStore = {
    nickname: "",
    id: 0,
    isInitialized: false,
}

export const profileReducer = (store = initialStore, action) => {
    switch (action.type) {
        case CHANGE_PROFILE: {
            return {
                ...store,
                ...action.payload,
            }
        }
        case INIT_PROFILE: {
            return {
                ...store,
                ...action.payload,
                isInitialized: true,
            }
        }
        default:
            return store;
    }
}
