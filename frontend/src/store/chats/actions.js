import { ADD_CHAT, INIT_CHAT_LIST } from "./types";


const API_URL = "/api/chat";
const UPDATE_INTERVAL = 1000;

export const addChatAction = (chat) => ({ type: ADD_CHAT, payload: chat });
const initChatList = (chatList, timer) => ({ type: INIT_CHAT_LIST, payload: { chatList: chatList, timer: timer } });

export const initChatListAction = () =>
    (dispatch) => {
        const timer = setInterval(async () => {
            const response = await fetch(API_URL);
            const chatList = await response.json();
            dispatch(initChatList(chatList, timer));
        }, UPDATE_INTERVAL);
    };