import { ChatModel } from "../../../models/ChatModel";
import { ADD_CHAT, INIT_CHAT_LIST, SELECT_CURRENT_CHAT } from "./types";


const API_URL = "/api/chat";
const UPDATE_INTERVAL = 250;

export const addChatAction = (chat) => ({ type: ADD_CHAT, payload: chat });
export const selectChatAction = (chatId) => ({ type: SELECT_CURRENT_CHAT, payload: chatId });
const initChatList = (chatList, timer) => ({ type: INIT_CHAT_LIST, payload: { chatList, timer } });

export const initChatListAction = () =>
    (dispatch) => {
        if (process.env.NODE_ENV == "development") {
            const devChatList = [
                new ChatModel("1", "Dev Chat 1"),
                new ChatModel("2", "Dev Chat 2"),
                new ChatModel("3", "Dev Chat 3"),
                new ChatModel("4", "Dev Chat 4"),
                new ChatModel("5", "Dev Chat 5"),
            ];

            return dispatch(initChatList(devChatList, 1));
        }

        const timer = setInterval(async () => {
            const response = await fetch(API_URL);
            const chatList = await response.json();
            dispatch(initChatList(chatList, timer));
        }, UPDATE_INTERVAL);
    };
