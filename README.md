<img src="https://i.imgur.com/lfGWDPq.png" height="80px" />

> switching up your Spotify experience with microfrontends and Blazor

<br/>

[![Netlify Status](https://api.netlify.com/api/v1/badges/2bdf60ef-23d4-4fe4-9868-38198d2ae582/deploy-status)](https://app.netlify.com/sites/spiralfy/deploys)
[![](https://img.shields.io/website?color=1ed45f&style=flat-square&up_message=spiralfy.party&url=https%3A%2F%2Fspiralfy.party)](https://spiralfy.party)

<p>
<span className="text-lightgray">Made with</span>
<span>
  <a target="_blank" href="https://reactjs.org">
    <img id="react-logo" src="https://i.imgur.com/gNxwwn1.png" height="10" />
    React
  </a>
</span>
<span className="text-lightgray">,</span>
<span>
  <a href="https://blazor.net" rel="nofollow">
    <img
      src="https://devblogs.microsoft.com/aspnet/wp-content/uploads/sites/16/2019/04/BrandBlazor_nohalo_1000x.png"
      height="10"
    />
    Blazor
  </a>
</span>
<span className="text-lightgray">and</span>
<span>
  <a target="_blank" href="https://piral.io">
    <img id="piral-logo" src="https://piral.io/logo-simple.f8667084.png" height="10" />
    Piral
  </a>
</span>
</p>

<a target="_blank" href="https://spiralfy.party">
<img src="https://i.imgur.com/GM0W1xr.gif">
</a>

---

<!-- TODO -->
<!--
## Article

<figure>
<center>
<a target="_blank" href="https://dev.to/dantederuwe/">
<img src="https://i.imgur.com/JqW4EnU.jpg">
<figcaption>In this DEVCommunity article, I share my experiences creating a microfrontend web app with Blazor and Piral. I also give a little behind-the-scenes look at how this was made possible.</figcaption>
</a>
</center>
</figure>
-->

## About

First of all, let's discuss the demo application that I created to showcase the use of Blazor with Piral: Spiralfy. A clever &ndash; or some would say _cheesy_ &ndash; play on words between Spotify and Piral, of course. But what does it do?

Log in with your Spotify premium account, and access a way to switch up your Spotify experience!

For a long time now, I wanted a way to shuffle play my playlists. I'm not talking about shuffling the songs within one playlist, that's something you can obviously already do. The feature I wanted could be described as "swiping through playlists": Spiralfy picks one playlist at random, shuffle playing its songs, and whenever you feel like you want a different _vibe_, you let Spiralfy pick a new playlist to listen to.

(I got inspired in part by [lofi.cafe](https://lofi.cafe), where you can switch through curated lofi playlists like they were radio stations. But I wanted the user to be able to use their own Spotify playlists instead.)

## Structure

For now, Spiralfy exists in 3 parts:

- the Piral instance: `spiralfy-appshell`
- the `player` pilet
- the `controls` pilet

(In the Piral framework, pilets are the individual feature modules, also known as microfrontends. Pilets are usually published to a feed service. The Piral instance (aka app shell) will pull all registered pilets from the feed service, and put them where they need to go as defined by the pilets themselves.)
