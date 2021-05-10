import { ADD_MESSAGE, LOAD_MESSAGES } from "./types";
import MessageModel from "../../model/MessageModel";

const API_URL = "";

const initialStore = () => {
    loadMessages();
    return {
        messageList: [
            new MessageModel("bot", "hallo"),
            new MessageModel("bot", "Message 1"),
            new MessageModel("bot", "Message 2"),
            new MessageModel("bot", "Message 3"),
        ],
    }
}

export const messageReduser = (store = initialStore(), action) => {
    switch (action.type) {
        case ADD_MESSAGE: {
            return {
                ...store,
                messageList: [...store.messageList, action.payload],
            }
        }
        case LOAD_MESSAGES: {
            return {
                ...store,
                messageList: payload,
            }
        }
        default:
            return store;
    }
}

const loadMessages = () => {
    fetch(API_URL)
        .then(res => res.json())
        .then(mes => console.log(mes))
        .catch((e) => console.log(`failed feath: ${e}`));
}