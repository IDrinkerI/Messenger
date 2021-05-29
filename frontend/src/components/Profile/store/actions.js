import { CHANGE_PROFILE, INIT_PROFILE } from "./types";


const API_URL = "/api/profile";

const initProfile = (state) => ({ type: INIT_PROFILE, payload: state });
const changeProfile = (state) => ({ type: CHANGE_PROFILE, payload: state });

export const initProfileAction =  () =>
    async (dispatch, getState) => {
        if (!getState().profile.isInitialized) {
            let devState = {};

            if (process.env.NODE_ENV == "development") {
                devState = {
                    nickname: "Developer",
                    id: 777,
                }
            }
            else {
                const response = await fetch(API_URL);
                devState = await response.json();
            }

            dispatch(initProfile(devState));
        }
    }

export const changeProfileAction = (state) =>
    (dispatch) => {
        if (process.env.NODE_ENV == "development") {
            return dispatch(changeProfile(state));
        }
        else {
            // Fetch
        }
    }
