import { ADD_MESSAGE, INIT_MESSAGE_STORE } from "./types";
import { MessageModel } from "../../../models/MessageModel";


const API_URL = "/api/message";
const UPDATE_INTERVAL = 250;

const addMessage = (message) => ({ type: ADD_MESSAGE, payload: message });
const initMessageStore = (messageList, timer) => ({ type: INIT_MESSAGE_STORE, payload: { messageList, timer } });

export const initMessageStoreAction = () =>
    (dispath, getState) => {
        if (getState().messages.updateTimer) return;

        if (process.env.NODE_ENV == "development") {
            const devMessageList = [
                new MessageModel("TestBot", "Hallo!"),
                new MessageModel("TestBot", "Some message"),
                new MessageModel("TestBot", "Some message"),
                new MessageModel("TestBot", "Some message"),
            ];

            return dispath(initMessageStore(devMessageList, 1));
        }

        const timer = setInterval(async () => {
            const currentChatId = getState().chats.currentChatId;
            const response = await fetch(API_URL + `/${currentChatId}`);
            const messageList = await response.json();
            dispath(initMessageStore(messageList, timer));
        }, UPDATE_INTERVAL);
    }

export const addMessageAction = (message) =>
    (dispatch, setState) => {
        if (process.env.NODE_ENV == "development") {
            dispatch(addMessage(message));
            return;
        }

        const chatId = setState().chats.currentChatId;

        fetch(API_URL, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ ...message, chatId })
        });
    }
