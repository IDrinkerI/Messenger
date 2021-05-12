import { ADD_CHAT, ADD_CHAT_LIST } from "./types";


export const addChatAction = (chat) => ({ type: ADD_CHAT, payload: chat });
export const addChatListAction = (chatList) => ({ type: ADD_CHAT_LIST, payload: chatList });