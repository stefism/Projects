import axios from "axios";

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
      }
    }
  },
  async created() {
    //created() - live cycle
    console.warn('Inside mixins.')
    await this.fetchData();
  }
};

export default tableMixin;
