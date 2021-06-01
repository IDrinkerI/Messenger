import { INPUT_MESSAGE_UPDATE } from "./types"


const initStore = {
    text: "",
}

export const inputMessageReducer = (store = initStore, action) => {
    switch (action.type) {
        case INPUT_MESSAGE_UPDATE: {
            return {
                ...store,
                text: action.payload,
            }
        }
        default:
            return store;
    }
}
