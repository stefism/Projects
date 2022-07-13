import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    sampleBlogCards: [
      { blogTitle: 'Блог карта 1', blogCoverPhoto: 'stock-1', blogDate: '1 Май 2022 г.'},
      { blogTitle: 'Блог карта 2', blogCoverPhoto: 'stock-2', blogDate: '15 Май 2022 г.'},
      { blogTitle: 'Блог карта 3', blogCoverPhoto: 'stock-3', blogDate: '11 Юни 2022 г.'},
      { blogTitle: 'Блог карта 4', blogCoverPhoto: 'stock-3', blogDate: '12 Юли 2022 г.'}
    ],
    editPost: null
  },
  mutations: {
    toggleEditPost(state, payload) {
      state.editPost = payload;
    }
  },
  actions: {
  },
  modules: {
  }
})
