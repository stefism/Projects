<template>
  <div>
    <h2>Characters table</h2>
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
      <el-table-column prop="gender" label="Gender"> </el-table-column>
      <el-table-column prop="species" label="Species"> </el-table-column>
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
  }
};
</script>

<style></style>
