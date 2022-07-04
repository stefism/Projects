<template>
  <div>
    <h2>Episodes table</h2>
    <el-pagination
        v-if="pagination"
        background 
        layout="prev, pager, next"
        :page-count="pagination.pages"
        @current-change="onCurrentCange"
    >
    </el-pagination>
    <el-table :data="tableData" v-loading="isLoading">
      <!-- v-loading - директива, която също идва от ElementUI. -->
      <el-table-column prop="name" label="Name"> </el-table-column>
      <el-table-column prop="air_date" label="Air Date"> </el-table-column>
      <el-table-column prop="episode" label="Episode"> </el-table-column>
      <el-table-column prop="created" label="Created"> </el-table-column>
    </el-table>
    <el-pagination
        v-if="pagination"
        background 
        layout="prev, pager, next"
        :current-page="page"
        :page-count="pagination.pages"
        @current-change="onCurrentCange"
    >
    </el-pagination>
  </div>
</template>
<script>
import tableMixin from '../mixins/table-mixin.js';

export default {
  mixins: [tableMixin],
  data() {
    return {
      isLoading: true,
      endpoint: 'episode'
    };
  },
  methods: {
    onCurrentCange(page) {
        this.page = page;
        this.isLoading = true;
        this.fetchData(page);
        this.isLoading = false;
        //Тук page се подава автоматчно от елемента el-pagination на ElementUI библиотеката през евента @current-change.
    }
  },
  created() {
    console.log('Inside table component.');
    this.isLoading = false;
  }
};
</script>

<style></style>
