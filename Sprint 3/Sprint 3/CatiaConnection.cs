﻿using System;
using System.Windows;
using INFITF;
using MECMOD;
using PARTITF;
using HybridShapeTypeLib;
using KnowledgewareTypeLib;
using ProductStructureTypeLib;


namespace Sprint_3
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;

        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeProfil(Zahnrad Zahnrad1)
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();

            //Nullpunkt
            double x0 = 0;
            double y0 = 0;

            //Hilfsgrößen von Wilkos PDF
            double Teilkreisradius = Zahnrad1.d / 2;
            double Hilfskreisradius = Teilkreisradius * 0.94;
            double Fußkreisradius = Teilkreisradius - (1.25 * Zahnrad1.m);
            double Kopfkreisradius = Teilkreisradius + Zahnrad1.m;
            double Verrundungsradius = 0.35 * Zahnrad1.m;

            double Alpha = 20;
            double Beta = 90 / Zahnrad1.z;
            double Betarad = Math.PI * Beta / 180;
            double Gamma = 90 - (Alpha - Beta);
            double Gammarad = Math.PI * Gamma / 180;
            double Totalangel = 360.0 / Zahnrad1.z;
            double Totalangelrad = Math.PI * Totalangel / 180;


            //Punkte
            //LinkerEvolKreis Mittelp. Koordinaten
            double xMPEvo_links = Hilfskreisradius * Math.Cos(Gammarad);
            double yMPEvo_links = Hilfskreisradius * Math.Sin(Gammarad);

            //Schnittpkt. auf Evolvente und Teilkreisradius
            double xPunktAufEvolvente = -Teilkreisradius * Math.Sin(Betarad);
            double yPunktAufEvolvente = Teilkreisradius * Math.Cos(Betarad);

            //Evolventenkreis Radius
            double EvolventenkreisRadius = Math.Sqrt(Math.Pow((xMPEvo_links - xPunktAufEvolvente), 2) + Math.Pow((yMPEvo_links - yPunktAufEvolvente), 2));

            //Koordinaten Schnittpunkt Kopfkreis und Evolventenkreis
            double xEvolventenkopfkreis_links = Schnittpunkt_X(x0, y0, Kopfkreisradius, xMPEvo_links, yMPEvo_links, EvolventenkreisRadius);
            double yEvolventenkopfkreis_links = Schnittpunkt_Y(x0, y0, Kopfkreisradius, xMPEvo_links, yMPEvo_links, EvolventenkreisRadius);

            //Mittelpunktkoordinaten Verrundung
            double xMittelpunktVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius + Verrundungsradius, xMPEvo_links, yMPEvo_links, EvolventenkreisRadius + Verrundungsradius);
            double yMittelpunktVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius + Verrundungsradius, xMPEvo_links, yMPEvo_links, EvolventenkreisRadius + Verrundungsradius);

            //Schnittpubktkoordinaten Verrundung - Evolventenkreis
            double x_SP_EvolventeVerrundung_links = Schnittpunkt_X(xMPEvo_links, yMPEvo_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_EvolventeVerrundung_links = Schnittpunkt_Y(xMPEvo_links, yMPEvo_links, EvolventenkreisRadius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Schnittpunktkoordinaten Verrundung - Fußkreis
            double x_SP_FußkreisradiusVerrundung_links = Schnittpunkt_X(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);
            double y_SP_FußkreisradiusVerrundung_links = Schnittpunkt_Y(x0, y0, Fußkreisradius, xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius);

            //Koordinaten Anfangspunkt Fußkreis
            double Hilfswinkel = Totalangelrad - Math.Atan(Math.Abs(x_SP_FußkreisradiusVerrundung_links) / Math.Abs(y_SP_FußkreisradiusVerrundung_links));
            double x_AnfangspunktFußkreis = Fußkreisradius * Math.Sin(Hilfswinkel);
            double y_AnfangspunktFußkreis = Fußkreisradius * Math.Cos(Hilfswinkel);

            //Skizze umbenennen und öffnen
            hsp_catiaProfil.set_Name("Zahnradskizze");
            Factory2D catfactory2D1 = hsp_catiaProfil.OpenEdition();

            //Nun die Punkte in die Skizze
            Point2D Ursprung = catfactory2D1.CreatePoint(x0, y0);
            Point2D EndpunktEvolventenkreis = catfactory2D1.CreatePoint(x_AnfangspunktFußkreis, y_AnfangspunktFußkreis);
            Point2D VerrundungLinksAnfang = catfactory2D1.CreatePoint(x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D VerrundungRechtsEnde = catfactory2D1.CreatePoint(-x_SP_FußkreisradiusVerrundung_links, y_SP_FußkreisradiusVerrundung_links);
            Point2D MPVerrundungLinks = catfactory2D1.CreatePoint(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D MPVerrundungRechts = catfactory2D1.CreatePoint(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links);
            Point2D VerrundungEndeLinks = catfactory2D1.CreatePoint(x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D VerrundungAnfangRechts = catfactory2D1.CreatePoint(-x_SP_EvolventeVerrundung_links, y_SP_EvolventeVerrundung_links);
            Point2D MPEvolventeLinks = catfactory2D1.CreatePoint(xMPEvo_links, yMPEvo_links);
            Point2D MPEvolventeRechts = catfactory2D1.CreatePoint(-xMPEvo_links, yMPEvo_links);
            Point2D EvolventenEndeLinks = catfactory2D1.CreatePoint(xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);
            Point2D EvolventenEndeRechts = catfactory2D1.CreatePoint(-xEvolventenkopfkreis_links, yEvolventenkopfkreis_links);

            //Kreise

            Circle2D Fußkreis = catfactory2D1.CreateCircle(x0, y0, Fußkreisradius, 0, Math.PI * 2);
            Fußkreis.CenterPoint = Ursprung;
            Fußkreis.StartPoint = EndpunktEvolventenkreis;
            Fußkreis.EndPoint = VerrundungRechtsEnde;

            Circle2D VerrundungLinks = catfactory2D1.CreateCircle(xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            VerrundungLinks.CenterPoint = MPVerrundungLinks;
            VerrundungLinks.StartPoint = VerrundungLinksAnfang;
            VerrundungLinks.EndPoint = VerrundungEndeLinks;

            Circle2D EvolventenkreisLinks = catfactory2D1.CreateCircle(xMPEvo_links, yMPEvo_links, EvolventenkreisRadius, 0, Math.PI * 2);
            EvolventenkreisLinks.CenterPoint = MPEvolventeLinks;
            EvolventenkreisLinks.StartPoint = EvolventenEndeLinks;
            EvolventenkreisLinks.EndPoint = VerrundungEndeLinks;

            Circle2D Kopfkreis = catfactory2D1.CreateCircle(x0, y0, Kopfkreisradius, 0, Math.PI * 2);
            Kopfkreis.CenterPoint = Ursprung;
            Kopfkreis.StartPoint = EvolventenEndeRechts;
            Kopfkreis.EndPoint = EvolventenEndeLinks;

            Circle2D EvolventenkreisRechts = catfactory2D1.CreateCircle(-xMPEvo_links, yMPEvo_links, EvolventenkreisRadius, 0, Math.PI * 2);
            EvolventenkreisRechts.CenterPoint = MPEvolventeRechts;
            EvolventenkreisRechts.StartPoint = VerrundungAnfangRechts;
            EvolventenkreisRechts.EndPoint = EvolventenEndeRechts;

            Circle2D VerrundungRechts = catfactory2D1.CreateCircle(-xMittelpunktVerrundung_links, yMittelpunktVerrundung_links, Verrundungsradius, 0, Math.PI * 2);
            VerrundungRechts.CenterPoint = MPVerrundungRechts;
            VerrundungRechts.StartPoint = VerrundungAnfangRechts;
            VerrundungRechts.EndPoint = VerrundungRechtsEnde;

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();

            ShapeFactory shapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)hsp_catiaPart.Part.HybridShapeFactory;

            Factory2D factory2D1 = hsp_catiaProfil.Factory2D;

            HybridShapePointCoord ursprung = hybridShapeFactory1.AddNewPointCoord(0, 0, 0);
            Reference refUrsprung = hsp_catiaPart.Part.CreateReferenceFromObject(ursprung);

            HybridShapeDirection xRichtung = hybridShapeFactory1.AddNewDirectionByCoord(1, 0, 0);
            Reference refxRichtung = hsp_catiaPart.Part.CreateReferenceFromObject(xRichtung);

            CircPattern kreismuster = shapeFactory1.AddNewSurfacicCircPattern(factory2D1, 1, 2, 0, 0, 1, 1, refUrsprung, refxRichtung, false, 0, true, false);
            kreismuster.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;
            AngularRepartition angularRepartition1 = kreismuster.AngularRepartition;
            Angle angle1 = angularRepartition1.AngularSpacing;
            angle1.Value = Convert.ToDouble(360 / Zahnrad1.z);
            AngularRepartition angularRepartition2 = kreismuster.AngularRepartition;
            IntParam intParam1 = angularRepartition2.InstancesCount;
            intParam1.Value = Convert.ToInt32(Zahnrad1.z) + 1;


            //Kreismusterenden verbinden

            Reference refKreismuster = hsp_catiaPart.Part.CreateReferenceFromObject(kreismuster);
            HybridShapeAssemble verbindung = hybridShapeFactory1.AddNewJoin(refKreismuster, refKreismuster);
            Reference refVerbindung = hsp_catiaPart.Part.CreateReferenceFromObject(verbindung);

            hybridShapeFactory1.GSMVisibility(refVerbindung, 0);

            hsp_catiaPart.Part.MainBody.InsertHybridShape(verbindung);

            hsp_catiaPart.Part.Update();

            ErzeugeBlock(Zahnrad1, refVerbindung, shapeFactory1);


            Sketches sketchesBohrung = catHybridBody1.HybridSketches;
            OriginElements catoriginelements = hsp_catiaPart.Part.OriginElements;
            Reference refmxPlaneX = (Reference)catoriginelements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(refmxPlaneX);

            ErzeugeAchsensystem();

            hsp_catiaPart.Part.Update();

            hsp_catiaProfil.set_Name("Bohrung");

            Factory2D catfactory2D2 = hsp_catiaProfil.OpenEdition();

            Circle2D KreisFürBohrungsskizze = catfactory2D2.CreateClosedCircle(x0, y0, Zahnrad1.bd / 2);

            hsp_catiaProfil.CloseEdition();

            hsp_catiaPart.Part.Update();

            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
            Pocket Tasche = shapeFactory1.AddNewPocket(hsp_catiaProfil, Zahnrad1.b);
            hsp_catiaPart.Part.Update();
        }

        public void ErzeugeBlock(Zahnrad Zahnrad1, Reference refVerbindung, ShapeFactory sf1)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;
            Pad catPad1 = sf1.AddNewPadFromRef(refVerbindung, Zahnrad1.b);
            catPad1.set_Name("Block");
            hsp_catiaPart.Part.Update();
        }

        private double Schnittpunkt_X(double xMittelpunkt, double yMittelpunkt, double radius1, double xMittelpunkt2, double yMittelpunkt2, double radius2)
        {
            double d = Math.Sqrt(Math.Pow((xMittelpunkt - xMittelpunkt2), 2) + Math.Pow((yMittelpunkt - yMittelpunkt2), 2));
            double l = (Math.Pow(radius1, 2) - Math.Pow(radius2, 2) + Math.Pow(d, 2)) / (d * 2);
            double h;
            double kontrollWert = 0.00001;

            if (radius1 - l < -kontrollWert)
            {
                MessageBox.Show("Fehler X");
            }
            if (Math.Abs(radius1 - l) < kontrollWert)
            {
                h = 0;
            }
            else
            {
                h = Math.Sqrt(Math.Pow(radius1, 2) - Math.Pow(l, 2));
            }

            return l * (xMittelpunkt2 - xMittelpunkt) / d - h * (yMittelpunkt2 - yMittelpunkt) / d + xMittelpunkt;
        }

        private double Schnittpunkt_Y(double xMittelpunkt, double yMittelpunkt, double radius1, double xMittelpunkt2, double yMittelpunkt2, double radius2)
        {
            double d = Math.Sqrt(Math.Pow((xMittelpunkt - xMittelpunkt2), 2) + Math.Pow((yMittelpunkt - yMittelpunkt2), 2));
            double l = (Math.Pow(radius1, 2) - Math.Pow(radius2, 2) + Math.Pow(d, 2)) / (d * 2);
            double h;
            double kontrollWert = 0.00001;

            if (radius1 - l < -kontrollWert)
            {
                MessageBox.Show("Fehler Y");
            }
            if (Math.Abs(radius1 - l) < kontrollWert)
            {
                h = 0;
            }
            else
            {
                h = Math.Sqrt(Math.Pow(radius1, 2) - Math.Pow(l, 2));
            }

            return l * (yMittelpunkt2 - yMittelpunkt) / d + h * (xMittelpunkt2 - xMittelpunkt) / d + yMittelpunkt;
        }

    }
}
