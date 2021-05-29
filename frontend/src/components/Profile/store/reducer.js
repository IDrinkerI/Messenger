import { CHANGE_NICKNAME } from "./types";


let nickname = "";

if (process.env.NODE_ENV == "development") {
    nickname = "Developer";
}

const initialStore = {
    nickname: nickname,
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
