import { ADD_CHAT, ADD_CHAT_LIST } from "./types";


const initialStore = {
    chatList: [
        "Chat 1",
        "Chat 2",
        "Chat 3",
        "Chat 4",
        "Chat 5",
    ],
}

export const chatsReducer = (store = initialStore, action) => {
    switch (action.type) {
        case ADD_CHAT: {
            return {
                ...store,
                chatList: [...store.chatList, action.payload],
            }
        }
        case ADD_CHAT_LIST: {
            return {
                ...store,
                chatList: action.payload,
            }
        }
        default:
            return store;
    }
}