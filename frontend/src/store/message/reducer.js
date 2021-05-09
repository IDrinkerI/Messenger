import { ADD_MESSAGE } from "./types";

const initialStore = {
    messageList: [],
}

export const messageReduser = (store = initialStore, action) => {
    switch (action.type) {
        case ADD_MESSAGE: {
            const messageList = store.messageList;
            messageList.push(action.payload);

            return {
                ...store,
                messageList,
            }
        }
        default:
            return store;
    }
}
