const state = {
  slides: [
    {
      cardType: 'TextSlide',
      id: 1,
      isActive: true,
      isDeleted: true,
      name: 'Testi textislide1',
      data: { title: 'title1', text: 'text1' }
    }
  ],
  isCarouselVisible: true
}

const getters = {}

const actions = {}

const mutations = {
  updateSlides (state, newSlides) {
    state.slides = newSlides.slides
  },
  hideSlides (state) {
    state.isCarouselVisible = false
  },
  showSlides (state) {
    state.isCarouselVisible = true
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
