import { MessageModel } from "../../../models/MessageModel";
import { ADD_MESSAGE, INIT_MESSAGE_STORE } from "./types";


let messageList = [];

if (process.env.NODE_ENV == "development")
    messageList = [
        new MessageModel("TestBot", "Hallo!"),
        new MessageModel("TestBot", "Some message"),
        new MessageModel("TestBot", "Some message"),
        new MessageModel("TestBot", "Some message"),
    ];

const initialStore = () => ({
    messageList,
    updateTimer: null,
});

export const messageReduser = (store = initialStore(), action) => {
    switch (action.type) {
        //TODO: delete this case
        case ADD_MESSAGE: {
            return {
                ...store,
                messageList: [...store.messageList, action.payload],
            }
        }
        case INIT_MESSAGE_STORE: {
            return {
                ...store,
                messageList: action.payload.messageList,
                updateTimer: action.payload.timer,
            }
        }
        default:
            return store;
    }
}
