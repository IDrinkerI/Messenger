import { CHANGE_PROFILE } from "./types";


const initialStore = {
    nickname: "",
    id: 0,
}

export const profileReducer = (store = initialStore, action) => {
    switch (action.type) {
        case CHANGE_PROFILE: {
            return {
                ...store,
                ...action.payload,
            }
        }
        default:
            return store;
    }
}
