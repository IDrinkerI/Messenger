import { ADD_MESSAGE, INIT_MESSAGE_STORE } from "./types";
import { MessageModel } from "../../../models/MessageModel";
import { RestClient } from "../../../utils";


const API_URL = "message/";
const UPDATE_INTERVAL = 250;

const addMessage = (message) => ({ type: ADD_MESSAGE, payload: message });
const initMessageStore = (messageList, timer) => ({ type: INIT_MESSAGE_STORE, payload: { messageList, timer } });

export const initMessageStoreAction = () =>
    (dispath, getState) => {
        if (getState().messages.updateTimer) return;

        if (process.env.NODE_ENV == "development") {
            const devMessageList = [
                new MessageModel(1, "TestBot", "Hallo!", 1, 1),
                new MessageModel(1, "TestBot", "Some message", 1, 1),
                new MessageModel(1, "TestBot", "Next message", 1, 1),
            ];

            return dispath(initMessageStore(devMessageList, 1));
        }

        const timer = setInterval(async () => {
            const currentChatId = getState().chats.currentChatId;
            const messageList = await RestClient.getAsync(API_URL + currentChatId);

            dispath(initMessageStore(messageList, timer));
        }, UPDATE_INTERVAL);
    }

export const addMessageAction = (message) =>
    (dispatch, getState) => {
        if (process.env.NODE_ENV == "development") {
            message.nickname = "Developer";
            dispatch(addMessage(message));
            return;
        }

        const profileId = getState().profile.id;
        message.profileId = profileId;

        RestClient.putAsync(API_URL, message);
    }
