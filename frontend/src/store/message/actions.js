const { ADD_MESSAGE, INIT_MESSAGE_STORE } = require("./types");


const API_URL = "/api/message";
const UPDATE_INTERVAL = 1000;

export const addMessage = (message) => ({ type: ADD_MESSAGE, payload: message });
const initMessageStore = (messageList, updateTimer) => ({ type: INIT_MESSAGE_STORE, payload: { messageList, updateTimer } });

export const initMessageStoreAction = () =>
    (dispath, getState) => {
        if (getState().message.updateTimer) return;

        const timer = setInterval(async () => {
            const currentChatId = getState().chats.currentChatId;
            const response = await fetch(API_URL+`/${currentChatId}`);
            const messageList = await response.json();
            dispath(initMessageStore(messageList, timer));
        }, UPDATE_INTERVAL);
    }

export const addMessageAction = (message) =>
    (dispatch) => {
        if (process.env.NODE_ENV == "development") {
            dispatch(addMessage(message));
            return;
        }

        fetch(API_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(message)
        });
    }