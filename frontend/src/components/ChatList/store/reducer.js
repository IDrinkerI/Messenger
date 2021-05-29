import { ChatModel } from "../../../models/ChatModel";
import { ADD_CHAT, INIT_CHAT_LIST, SELECT_CURRENT_CHAT } from "./types";


let chatList = [];

if (process.env.NODE_ENV == "development")
    chatList = [
        new ChatModel("1", "Dev Chat 1"),
        new ChatModel("2", "Dev Chat 2"),
        new ChatModel("3", "Dev Chat 3"),
        new ChatModel("4", "Dev Chat 4"),
        new ChatModel("5", "Dev Chat 5"),
    ];

const initialStore = {
    chatList: chatList,
    updateTimer: null,
    currentChatId: null
}

export const chatsReducer = (store = initialStore, action) => {
    switch (action.type) {
        case ADD_CHAT: {
            return {
                ...store,
                chatList: [...store.chatList, action.payload],
            }
        }
        case INIT_CHAT_LIST: {
            return {
                ...store,
                chatList: action.payload.chatList,
                updateTimer: action.payload.timer,
            }
        }
        case SELECT_CURRENT_CHAT: {
            return {
                ...store,
                currentChatId: action.payload,
            }
        }
        default:
            return store;
    }
}
