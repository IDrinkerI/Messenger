import { INPUT_MESSAGE_UPDATE } from "./types";


export const updateInputMessageAction = (text = "") => ({ type: INPUT_MESSAGE_UPDATE, payload: text });
