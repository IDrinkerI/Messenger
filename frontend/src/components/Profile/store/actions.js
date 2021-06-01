import { CHANGE_PROFILE } from "./types";


const API_URL = "/api/profile";
const changeProfile = (state) => ({ type: CHANGE_PROFILE, payload: state });

export const initProfileAction = () =>
    async (dispatch) => {
        let state = {};

        if (process.env.NODE_ENV == "development") {
            state = {
                nickname: "Developer",
                id: 777,
            }
        }
        else {
            const response = await fetch(API_URL);
            state = await response.json();
        }

        dispatch(changeProfile(state));
    }

export const changeProfileAction = (state) =>
    (dispatch, getState) => {
        if (process.env.NODE_ENV == "development") {
            return dispatch(changeProfile(state));
        }

        fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ ...getState().profile, ...state }),
        });
    }
