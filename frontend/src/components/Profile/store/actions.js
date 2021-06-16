import { RestClient } from "../../../utils";
import { CHANGE_PROFILE } from "./types";


const API_URL = "profile/";
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
            state = await RestClient.getAsync(API_URL);
        }

        dispatch(changeProfile(state));
    }

export const changeProfileAction = (state) =>
    (dispatch, getState) => {
        if (process.env.NODE_ENV == "development") {
            return dispatch(changeProfile(state));
        }

        const newState = { ...getState().profile, ...state };
        RestClient.postAsync(API_URL, newState);
    }
