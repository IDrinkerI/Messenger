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
                new MessageModel("TestBot", "Hallo!", 1, 1),
                new MessageModel("TestBot", "Some message", 1, 1),
                new MessageModel("TestBot", "Some message", 1, 1),
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
        message.profileId = setState().profile.id;
        console.log("ProfileID: ", setState().profile.id)
        if (process.env.NODE_ENV == "development") {
            message.nickname = "Developer";
            dispatch(addMessage(message));
            return;
        }

        fetch(API_URL, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(message)
        });
    }
