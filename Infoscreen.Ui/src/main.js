// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import VueAgile from 'vue-agile'
import store from './store'

Vue.config.productionTip = false

Vue.use(VueAgile)

/* eslint-disable no-new */
window.vm = new Vue({
  el: '#app',
  store,
  components: { App, VueAgile },
  template: '<App/>',
  data: {
    sharedSlides: {}
  }
})
