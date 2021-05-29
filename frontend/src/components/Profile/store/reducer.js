import { CHANGE_NICKNAME } from "./types";

const initialStore = {
    nickname: "",
    id: 0,
}

export const profileReducer = (store = initialStore, action) => {
    switch (action.type) {
        case CHANGE_NICKNAME: {
            return {
                ...store,
                nickname: action.payload,
            }
        }
        default:
            return store;
    }
}
