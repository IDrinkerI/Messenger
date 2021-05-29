import { CHANGE_NICKNAME } from "./types";


export const changeNicknameAction = (name) => ({ type: CHANGE_NICKNAME, payload: name });
