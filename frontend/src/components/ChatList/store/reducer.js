import { ADD_CHAT, INIT_CHAT_LIST, SELECT_CURRENT_CHAT } from "./types";


const initialStore = {
    chatList: [],
    updateTimer: null,
    currentChatId: 0
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
