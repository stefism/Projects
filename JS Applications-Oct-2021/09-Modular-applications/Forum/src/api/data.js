import * as api from './api.js';

export const login = api.login;
export const logout = api.logout;
export const register = api.register;

export async function getAllTopics() {
    return api.get(`/data/topics?load=${encodeURIComponent('author=_ownerId:users,comments=_id:')}&select=_id,title,_ownerId`);
}

export async function createNewTopic(data) {
    return api.post('/data/topics', data);
}

export async function getTopicsCount() {
    return api.get('/data/topics?count');
}

export async function getTopicById(id) {
    return api.get(`/data/topics/${id}?load=${encodeURIComponent('author=_ownerId:users')}`);
}

export async function getCommentsByTopicId(topicId) {
    return api.get(`/data/topicComments?where=${encodeURIComponent(`topicId="${topicId}"`)}&load=${encodeURIComponent('author=_ownerId:users,comments=_id:')}`);
}

export async function createComment(comment) {
    api.post('/data/topicComments', comment);
}