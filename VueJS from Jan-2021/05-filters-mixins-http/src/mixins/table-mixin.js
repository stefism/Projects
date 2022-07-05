import axios from "axios";

// Interceptors
axios.interceptors.request.use(
  function(config) {
    console.log('From -request- interceptor config: ', config);
    return config;
  },
  function(error) {
    console.log('From -request- interceptor error: ', error);
    return Promise.reject(error);
  }
);

axios.interceptors.response.use(
  function(config) {
    console.log('From -response- interceptor config: ', config);
    return config;
  },
  function(error) {
    console.log('From -response- interceptor error: ', error);
    return Promise.reject(error);
  }
);
//Интерсепторите са нещо като мдълуерите в C#. Правят неща преди или след рекуеста и респонса. В случая идват от аксиос библиотеката заедно с него.

const tableMixin = {
  data() {
    return {
      tableData: [],
      pagination: null,
      page: 1,
      endpoint: 'character'
    };
  },
  methods: {
    async fetchData() {
      const url = `https://rickandmortyapi.com/api/${this.endpoint}/?page=${this.page}`;

      try {
        const responce = await axios.get(url);
        console.log("result: ", responce);
        this.tableData = responce.data.results;
        this.pagination = responce.data.info;
      } catch (error) {
        console.error('Error while loading endpoint. - ' + this.endpoint, error);
      } finally {
        //Този кот тук ще се изпълни винаги след try-catch блока, независимо дали кода е влязъл в try или в catch блока.
      }
    }
  },
  async created() {
    //created() - live cycle
    console.warn('Inside mixins.')
    await this.fetchData();
    this.isLoading = false;
  }
};

export default tableMixin;
