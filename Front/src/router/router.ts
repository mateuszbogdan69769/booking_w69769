import { createRouter, createWebHistory } from 'vue-router';
import { AccountRoutesTitles } from '@/data/AccountRoutesTitles';
import { BookingRoutesTitles } from '@/data/BookingRoutesTitles';
import { BookingRoutes } from '@/data/booking.routes';

const defaultRoute = {
  path: '/:pathMatch(.*)*',
  redirect: { name: AccountRoutesTitles.Login }
};

const routes = [
  {
    name: BookingRoutesTitles.Booking,
    path: `/main`,
    component: () => import('@/views/BookingMain.vue'),
    children: BookingRoutes,
    redirect: { name: BookingRoutesTitles.Home }
  },

  // # Account routes
  {
    name: AccountRoutesTitles.Account,
    path: `/account`,
    component: () => import('@/views/AccountMain.vue'),
    children: [
      {
        name: AccountRoutesTitles.Login,
        path: 'login',
        component: () => import('@/modules/Login/views/LoginView.vue')
      },
      {
        name: AccountRoutesTitles.Register,
        path: 'register',
        component: () => import('@/modules/Register/views/RegisterView.vue')
      }
    ],
    redirect: { name: AccountRoutesTitles.Login }
  }
];

const router = createRouter({
  history: createWebHistory('/'),
  routes: [...routes, defaultRoute]
});

export default router;
