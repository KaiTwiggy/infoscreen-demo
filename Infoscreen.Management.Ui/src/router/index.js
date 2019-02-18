import Vue from 'vue'
import Router from 'vue-router'
import Main from '@/components/Main'
import DeviceList from '@/components/DeviceList'
import AddSlide from '@/components/AddSlide'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/admin',
      name: 'FrontPage',
      component: Main
    },
    {
      path: '/admin/Devices',
      name: 'DeviceList',
      component: DeviceList
    },
    {
      path: '/admin/AddSlide',
      name: 'AddSlide',
      component: AddSlide
    }
  ],
  mode: 'history'
})
