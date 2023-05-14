﻿using BrowserInterop.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MM.Shared;
using MM.Shared.Models.Profile;
using MM.WEB.Modules.Profile.Core;
using VerusDate.Web.Api;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileData : PageCore<ProfileData>
    {
        [Inject] protected ProfileApi ProfileApi { get; set; } = default!;
        [Inject] protected InviteApi InviteApi { get; set; } = default!;
        [Inject] protected MapApi MapApi { get; set; } = default!;
        [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;

        private ProfileModel? profile = new();

        private GeoLocation? GPS = new();

        protected override async Task LoadData()
        {
            LoadingProfile?.Start();
            profile = await ProfileApi.Profile_Get();
            LoadingProfile?.Finish(profile == null);

            profile ??= new()
            {
                GenderIdentity = GenderIdentity.Cisgender,
                SexualOrientation = SexualOrientation.Heterosexual,
                BirthDate = DateTime.UtcNow.AddYears(-18).AddDays(1).Date,
                Diet = Diet.Omnivore,
            };
        }

        private async Task SetLocation(ProfileModel profile)
        {
            if (profile != null /*&& !profile.Longitude.HasValue*/)
            {
                var window = await JsRuntime.Window();
                var navigator = await window.Navigator();
                var position = await navigator.Geolocation.GetCurrentPosition();

                if (position.Error != null)
                {
                    await Toast.Warning(position.Error.Message);
                }
                else if (position.Location != null)
                {
                    GPS.Latitude = position.Location.Coords.Latitude;
                    GPS.Longitude = position.Location.Coords.Longitude;
                    GPS.Accuracy = position.Location.Coords.Accuracy;

                    //TODO: chamar código da api
                    var here = await MapApi.GetLocation(GPS.Latitude, GPS.Longitude);
                    if (here != null && here.items.Any())
                    {
                        var address = here.items[0].address;
                        profile.Location = address.GetLocation();

                        AddLanguages((Country)Enum.Parse(typeof(Country), address.countryCode));
                    }
                    else
                    {
                        profile.Location = "Localização Desconhecida";
                    }

                    //profile.Longitude = GPS.Longitude;
                    //profile.Latitude = GPS.Latitude;

                    //if (GPS.Accuracy > 500)
                    //{
                    //    Toast.ShowWarning("", $"A posição do GPS foi recuperada, mas a precisão é de apenas: {Math.Round(GPS.Accuracy / 1000, 1)} km. Tente novamente mais tarde ou use um dispositivo mais preciso.");
                    //}
                }
                else
                {
                    await Toast.Warning($"Não foi possível detectar um sistema GPS no seu dispositivo. Favor, tentar novamente ou liberar acesso ao GPS do seu dispositivo.");
                }
            }
        }

        private void AddLanguages(Country country)
        {
            //https://en.wikipedia.org/wiki/List_of_official_languages
            //https://en.wikipedia.org/wiki/List_of_official_languages_by_country_and_territory
            if (profile.Languages.Any()) return;

            switch (country)
            {
                case Country.CHN:
                    profile.Languages = new Language[] { Language.zh };
                    break;

                case Country.IND:
                    profile.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.USA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.IDN:
                    profile.Languages = new Language[] { Language.ms }; //Indonesian = It is a standardized variety of Malay
                    break;

                case Country.PAK:
                    profile.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.NGA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.BRA:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.BGD:
                    //profile.Languages = new Language[] { Language.Bengali };
                    break;

                case Country.RUS:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.MEX:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.JPN:
                    //profile.Languages = new Language[] { Language.Japanese };
                    break;

                case Country.ETH:
                    //Oromo, Amharic
                    break;

                case Country.PHL:
                    //Filipino (Tagalog)
                    break;

                case Country.EGY:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.VNM:
                    //profile.Languages = new Language[] { Language.Vietnamese };
                    break;

                case Country.COD:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.IRN:
                    profile.Languages = new Language[] { Language.fa };
                    break;

                case Country.TUR:
                    profile.Languages = new Language[] { Language.Turkish };
                    break;

                case Country.DEU:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.FRA:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.GBR:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.THA:
                    //Thai
                    break;

                case Country.ZAF:
                    //Zulu, Xhosa, Afrikaans, English
                    break;

                case Country.TZA:
                    profile.Languages = new Language[] { Language.sw, Language.en };
                    break;

                case Country.ITA:
                    profile.Languages = new Language[] { Language.it };
                    break;

                case Country.MMR:
                    //Burmese
                    break;

                case Country.KOR:
                    profile.Languages = new Language[] { Language.Korean };
                    break;

                case Country.COL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.KEN:
                    profile.Languages = new Language[] { Language.sw, Language.en };
                    break;

                case Country.ESP:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.ARG:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.DZA:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.SDN:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UGA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.IRQ:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UKR:
                    //Ukrainian
                    break;

                case Country.CAN:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.POL:
                    //Polish
                    break;

                case Country.MAR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UZB:
                    //Uzbek
                    break;

                case Country.SAU:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.PER:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.AGO:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.AFG:
                    profile.Languages = new Language[] { Language.fa }; //Dari, which is a variety of and mutually intelligible with Persian
                    //Pashto, Dari
                    break;

                case Country.MYS:
                    profile.Languages = new Language[] { Language.ms };
                    break;

                case Country.MOZ:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.GHA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.YEM:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.NPL:
                    //Nepali
                    break;

                case Country.VEN:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.CIV:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.MDG:
                    //Malagasy (official, and national language), French (official).
                    break;

                case Country.AUS:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.PRK:
                    profile.Languages = new Language[] { Language.Korean };
                    break;

                case Country.CMR:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.NER:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.TWN:
                    profile.Languages = new Language[] { Language.zh };
                    break;

                case Country.LKA:
                    //Sinhala
                    break;

                case Country.BFA:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.MWI:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.MLI:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.CHL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.KAZ:
                    //Kazakh, Russian
                    break;

                case Country.ROU:
                    profile.Languages = new Language[] { Language.ro };
                    break;

                case Country.ZMB:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.SYR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.ECU:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.NLD:
                    profile.Languages = new Language[] { Language.nl };
                    break;

                case Country.SEN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.GTM:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.TCD:
                    profile.Languages = new Language[] { Language.fr, Language.ar };
                    break;

                case Country.SOM:
                    profile.Languages = new Language[] { Language.Somali };
                    break;

                case Country.ZWE:
                    //Shona, English
                    break;

                case Country.KHM:
                    //Khmer
                    break;

                case Country.SSD:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.RWA:
                    //Kinyarwanda
                    break;

                case Country.GIN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BDI:
                    //Kirundi
                    break;

                case Country.BEN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BOL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.TUN:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.HTI:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BEL:
                    profile.Languages = new Language[] { Language.nl };
                    break;

                case Country.JOR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.CUB:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.GRC:
                    profile.Languages = new Language[] { Language.Greek };
                    break;

                case Country.DOM:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.CZE:
                    //Czech
                    break;

                case Country.SWE:
                    profile.Languages = new Language[] { Language.Swedish };
                    break;

                case Country.PRT:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.AZE:
                    //Azerbaijani
                    break;

                case Country.HUN:
                    //Hungarian
                    break;

                case Country.HND:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.ISR:
                    //Hebrew
                    break;

                case Country.TJK:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.BLR:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.ARE:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.PNG:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.AUT:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.CHE:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.SLE:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.TGO:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.HKG:
                    //Cantonese
                    break;

                case Country.PRY:
                    profile.Languages = new Language[] { Language.es };
                    break;

                default:
                    break;
            }
        }

        private async Task HandleValidSubmit()
        {
            if (profile == null) throw new InvalidOperationException("profile is null");

            try
            {
                //profile.Zodiac = profile.BirthDate.GetWesternZodiac();

                await ProfileApi.Profile_Update(profile);

                profile = await ProfileApi.Profile_Get(); //TODO update id field

                if (profile.Modality == Modality.Matchmaker)
                {
                    foreach (var item in profile.Partners)
                    {
                        //TODO: remove the conections on others users
                    }

                    profile.Partners = new List<Partner>();
                }
                else
                {
                    //var invites = NewInvites.Except(RemovedInvites).ToList();
                    //var principal = await PrincipalApi.Get();
                    //var emailUser = principal?.Email;

                    //foreach (var email in invites)
                    //{
                    //    var invite = await InviteApi.Invite_Get(email);
                    //    var newInvite = false;

                    //    if (invite == null)
                    //    {
                    //        invite = new InviteModel();
                    //        invite.Initialize(email);
                    //        newInvite = true;
                    //    }

                    //    invite.Invites.Add(new Invite(profile.Key, emailUser, InviteType.Partner));

                    //    if (newInvite)
                    //        await InviteApi.Invite_Add(invite);
                    //    else
                    //        await InviteApi.Invite_Update(invite);
                    //}

                    //foreach (var item in RemovedInvites)
                    //{
                    //    //TODO: remove removed invites
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }

        private async Task HandleInvalidSubmit(EditContext context)
        {
            if (profile == null) throw new InvalidOperationException("profile is null");

            var errors = context.GetValidationMessages().ToList();

            if (errors != null && errors.Count == 1)
                await Toast.Warning(errors.First());
            else
                await Toast.Warning("Foram detectados erros de validação");
        }
    }
}