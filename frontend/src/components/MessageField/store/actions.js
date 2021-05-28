const { ADD_MESSAGE, INIT_MESSAGE_STORE } = require("./types");


const API_URL = "/api/message";
const UPDATE_INTERVAL = 500;

const addMessage = (message) => ({ type: ADD_MESSAGE, payload: message });
const initMessageStore = (messageList, timer) => ({ type: INIT_MESSAGE_STORE, payload: { messageList, timer } });

export const initMessageStoreAction = () =>
    (dispath, getState) => {
        if (getState().messages.updateTimer) return;

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
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ ...message, chatId })
        });
    }