import { ADD_CHAT, INIT_CHAT_LIST, SELECT_CURRENT_CHAT } from "./types";


const API_URL = "/api/chat";
const UPDATE_INTERVAL = 500;

export const addChatAction = (chat) => ({ type: ADD_CHAT, payload: chat });
export const selectChatAction = (chatId) => ({ type: SELECT_CURRENT_CHAT, payload: chatId });
const initChatList = (chatList, timer) => ({ type: INIT_CHAT_LIST, payload: { chatList, timer } });

export const initChatListAction = () =>
    (dispatch) => {
        const timer = setInterval(async () => {
            const response = await fetch(API_URL);
            const chatList = await response.json();
            dispatch(initChatList(chatList, timer));
        }, UPDATE_INTERVAL);
    };