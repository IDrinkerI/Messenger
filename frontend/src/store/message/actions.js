const { ADD_MESSAGE } = require("./types");

export const addMessageAction = (message) => ({ type: ADD_MESSAGE, payload: message })