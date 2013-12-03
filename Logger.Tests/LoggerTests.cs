using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Log_Should_Post_Message_Less_Than_4000_Characters()
        {
            var logger = new Streamline.Logging.Logger("http://api-logging.npc.local/v1/logs", "Logger Tests", "Logger");
            logger.LogAsync("Small Test Message 1").Wait();
        }


        [TestMethod]
        public void Log_Should_Post_Message_Less_Than_4000_Characters_At_Least_10_Times()
        {
            var logger = new Streamline.Logging.Logger("http://api-logging.npc.local/v1/logs", "Logger Tests", "Logger");

            for (var i = 0; i < 10; i++)
                logger.LogAsync(string.Format("Small Test Message {0}", i)).Wait();
        }


        [TestMethod]
        public void Log_Should_Post_Message_Greater_Than_4000_Characters()
        {
            var logger = new Streamline.Logging.Logger("http://api-logging.npc.local/v1/logs", "Logger Tests", "Logger");
            var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur imperdiet ac libero vitae dictum. Vivamus velit nisi, tempor eget varius quis, mollis quis sem. Vivamus ut consectetur sapien, in condimentum nunc. Aenean nulla mi, euismod eu convallis et, viverra ut orci. Etiam accumsan mauris eget sodales ultrices. Quisque auctor, elit sed vulputate volutpat, arcu mi consectetur sem, eu adipiscing sapien dolor quis neque. Duis hendrerit nisl et blandit ultrices. Nulla facilisi. Suspendisse nec vulputate dolor. Sed pretium dictum quam, sit amet dignissim eros aliquam id. Nulla lacus nisi, volutpat eget mauris non, dapibus vestibulum mauris. Suspendisse augue augue, vestibulum eget eleifend vestibulum, lobortis non dolor. Donec pharetra a ipsum at tincidunt. Nunc sed sapien interdum, sagittis sem non, tincidunt nisi. Cras eleifend euismod orci. Aenean hendrerit nulla ut est tristique pharetra.

                    Aliquam vel fringilla ligula, ut convallis nibh. Nullam ultricies vestibulum arcu ac suscipit. Aliquam nec aliquet libero. Donec egestas nibh ut ipsum pulvinar, non mollis nulla fringilla. Aliquam a rhoncus nibh. Nullam auctor ligula leo, eu sagittis dolor lobortis at. Donec urna odio, posuere a viverra nec, vehicula a massa. Vivamus suscipit, enim vitae fringilla luctus, dui sem suscipit leo, ac porttitor mi sem eu dui. Suspendisse adipiscing condimentum diam et tincidunt. Sed placerat malesuada tincidunt. Fusce sagittis massa sed urna ornare, ut dapibus turpis facilisis. Nam vitae mollis est. Aenean rutrum condimentum ultrices. Cras vulputate nibh quis est mollis sodales.

                    Ut in ligula malesuada odio semper posuere. Donec auctor lorem in dolor gravida aliquet. Vestibulum tempor, nibh vel iaculis suscipit, quam enim placerat lacus, eget tincidunt nulla arcu et eros. Aenean quis interdum urna, bibendum posuere leo. Pellentesque purus tortor, fermentum a neque at, adipiscing vulputate erat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus at mauris ac lorem pharetra porta. Nam pellentesque purus sit amet lacus malesuada, non consequat nunc eleifend. Morbi ornare nulla tellus, in feugiat nisi tempor nec.

                    Curabitur sagittis eros non turpis malesuada, sit amet aliquet massa vestibulum. Praesent sit amet est tincidunt, blandit risus eget, pretium felis. Aenean mauris tellus, lacinia a pellentesque ut, iaculis nec nulla. Phasellus sit amet lorem vitae nulla placerat tempor at at ante. Aliquam condimentum, est vitae consectetur dictum, risus nisl gravida lorem, ac blandit sem augue at urna. Pellentesque ipsum lectus, porta et tincidunt cursus, elementum non ligula. Aenean non scelerisque justo.

                    Aliquam erat volutpat. Integer cursus magna et mollis rutrum. Aenean quis odio nulla. Fusce fringilla erat vel libero vulputate, gravida dignissim magna venenatis. Etiam pretium magna velit, eu gravida est rhoncus a. Curabitur sodales odio id dui tempor malesuada. Quisque dapibus vestibulum sodales. Maecenas ultrices et arcu sed dapibus. Proin vulputate accumsan est, id tincidunt tortor feugiat ut. Quisque tortor eros, facilisis eu arcu nec, laoreet sodales erat. Nulla facilisi.

                    Phasellus ultricies velit at mattis gravida. Cras a magna porta, faucibus velit eu, porta magna. Nam vel nulla at libero adipiscing consectetur placerat vel sapien. Fusce fermentum nibh id dolor dapibus iaculis. Quisque in turpis ac ligula dignissim lobortis ac a tellus. Donec vel diam nulla. In hendrerit erat non ipsum vestibulum, eu laoreet lectus convallis. Phasellus vel egestas tellus. Praesent sollicitudin felis neque, vel dignissim dui imperdiet quis.

                    Donec vel lacus quis augue congue porttitor. Donec nec lectus tristique, fringilla mi sed, vestibulum turpis. Aenean lobortis nisi iaculis, accumsan orci vitae, eleifend ligula. Curabitur eu justo quis augue pellentesque varius. Cras a justo mattis, ullamcorper augue vitae, varius risus. Aliquam ut feugiat orci, eu pulvinar nulla. Nunc aliquet aliquam quam, ut pretium nibh egestas ut. Nam imperdiet sodales justo, ut venenatis sapien ullamcorper vitae. Morbi placerat, nisl aliquet placerat feugiat, lacus risus facilisis eros, vitae placerat magna nisi at enim. Fusce est nunc, hendrerit non nibh nec, rutrum cursus lacus. Ut placerat enim ut lorem faucibus scelerisque id in dui. Suspendisse potenti. Aliquam dignissim laoreet risus.

                    Pellentesque semper hendrerit velit, at pretium dui porttitor a. Proin facilisis tellus ac tellus consequat, ac rutrum lectus tristique. Fusce consequat neque nec neque consectetur facilisis. Aenean scelerisque laoreet pretium. Fusce condimentum bibendum eros a molestie. Phasellus arcu ipsum, viverra ac arcu sed, ornare tempus neque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed diam mi, vulputate vehicula ultrices id, rutrum in quam.

                    Etiam scelerisque congue ante quis commodo. Phasellus fringilla elit eu nunc posuere egestas quis eget est. Proin placerat pharetra venenatis. Praesent non dolor facilisis, ullamcorper arcu eget, consequat tortor. Phasellus rutrum viverra justo, vitae imperdiet velit consequat nec. Aliquam varius lacus eu orci dapibus tempus. Maecenas faucibus iaculis hendrerit. Cras dignissim, metus ut elementum vehicula, nisi justo varius tellus, id malesuada turpis dolor sed nibh. Cras porta lacinia purus vitae pretium. Sed tristique rhoncus mattis. Morbi mattis erat eu felis imperdiet eleifend. Quisque elementum placerat risus, eget euismod metus tristique eget. Aenean vel odio eget diam elementum sollicitudin quis a nulla. Aliquam et tortor justo. Sed luctus, eros ac cursus viverra, eros leo ullamcorper velit, ut lacinia risus magna et augue. Vivamus vitae nunc tortor.

                    Cras commodo, ipsum at tincidunt lacinia, nisi orci bibendum urna, quis sollicitudin nunc augue nec nibh. Pellentesque nec fermentum nisl. In nec viverra leo. Nulla quis orci nec enim porttitor pellentesque eget porta orci. Quisque nec nisi metus. Sed lacinia, libero a consectetur tempor, eros dui feugiat velit, non condimentum urna magna eu mi. Quisque convallis sodales porttitor. Sed porttitor metus ante, non elementum nibh consequat id. Vestibulum aliquam magna eget est tristique posuere. Maecenas est arcu, congue vel laoreet vitae, ornare quis ante. Donec eu tortor in sem sollicitudin pellentesque vel ut mi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed non euismod erat.

                    Sed porttitor, arcu non tincidunt gravida, mauris dui blandit tellus, ut bibendum risus lacus eu nisl. Nullam euismod eget lacus vel scelerisque. Morbi vel orci vel ante rhoncus consectetur. Ut auctor porta nulla, sed consequat augue volutpat aliquam. Fusce nec laoreet lorem. Morbi consectetur sed ipsum eu faucibus. Donec sit amet quam vel lectus vestibulum lacinia sed eget magna. Integer vel fringilla leo. Suspendisse nec vestibulum metus. Sed semper malesuada venenatis. Curabitur justo orci, commodo vitae est in, ornare fringilla nisl. Sed lacinia dapibus bibendum. Suspendisse vehicula risus ut molestie laoreet.

                    Proin ut arcu vitae orci venenatis aliquet et ac lacus. Duis in nibh neque. Sed vel imperdiet diam. Nam lacus justo, pellentesque eu velit a, sagittis placerat augue. Fusce quis tristique libero. Suspendisse vel tempor dolor. Phasellus ut metus vel nulla ornare molestie sit amet nec eros. Duis aliquam turpis massa, sed lacinia sapien laoreet in. Vivamus blandit, urna sit amet dapibus tincidunt, nulla urna aliquam eros, quis fermentum eros orci nec risus. Donec aliquam, eros non rhoncus tincidunt, turpis leo volutpat urna, eget fermentum est eros ac massa. Fusce nec eros a magna viverra iaculis at eu ante. Integer varius, libero vel viverra congue, eros libero facilisis ante, sit amet tincidunt elit mauris id mauris. Etiam nibh ante, molestie eu nisi a, ullamcorper vehicula nisl. Morbi vehicula lobortis eros, nec scelerisque orci porttitor id. Nam a orci eu massa elementum blandit.

                    Pellentesque ante est, tincidunt sed pulvinar non, imperdiet ut lacus. Duis tellus justo, congue sed odio sit amet, tincidunt interdum mauris. Vivamus fringilla est id risus consectetur fermentum id vitae tortor. Integer congue, sapien luctus viverra eleifend, ligula mauris ultrices ante, vel dapibus ante enim elementum metus. Sed ut sapien odio. Nunc ornare tortor elit, iaculis consectetur nisl rutrum vel. Nunc magna turpis, porttitor eget purus id, facilisis tristique purus. Cras id tincidunt justo.

                    Vivamus sagittis et mi a egestas. Etiam sed est orci. Integer diam est, aliquam non sapien eu, commodo pharetra odio. Mauris faucibus nunc nisi, scelerisque fringilla felis convallis vitae. Sed in condimentum est. Nullam at dapibus turpis. Duis ligula mauris, semper sit amet scelerisque sit amet, tempor eu libero. Donec at ligula ultrices erat tempus molestie. Vivamus eget mauris aliquam erat lacinia placerat eget luctus justo. Proin vestibulum lectus lorem, vel suscipit diam blandit in. Curabitur consequat viverra dolor, non pellentesque lorem convallis at.

                    Aenean sit amet facilisis mi. Mauris a ipsum rutrum, rutrum tellus a, consequat mauris. Nulla vel venenatis turpis. Praesent condimentum justo eget arcu venenatis, quis facilisis quam viverra. Donec blandit tellus a turpis cursus scelerisque. Ut sed convallis sem. Suspendisse venenatis bibendum semper. Pellentesque sapien lorem, consequat at rhoncus eu, rutrum eget leo. Fusce scelerisque dapibus lacus, ac porta tellus consequat non. Phasellus bibendum dignissim lectus vitae consequat. Sed eleifend tincidunt leo. Ut mattis egestas velit, non vestibulum enim lacinia ac. Duis sollicitudin lacus id urna tempus, non imperdiet nunc consequat. Cras non dolor ac enim ullamcorper posuere. Nunc feugiat, leo in consectetur sagittis, nibh neque sagittis ipsum, et porttitor mauris tellus ut dui.

                    In ac purus sit amet nunc laoreet semper. Sed vitae urna nisi. Mauris vel nibh pellentesque, consequat quam sit amet, eleifend ligula. Maecenas et nunc eleifend, viverra sapien et, rutrum lorem. In sodales elit dui. Donec sagittis at tortor vel suscipit. Aenean eget tellus sit amet sem eleifend fermentum quis sed ligula. Vestibulum sed cursus ligula. Cras rutrum, dolor ac pharetra tristique, sapien risus tincidunt felis, eu fermentum dui erat sed sem. Nam quam turpis, mattis eget tempor non, vestibulum non diam. Maecenas mauris augue, pretium et bibendum vel, ornare et velit. Maecenas ultrices quam quis suscipit semper. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed consequat tempus ante in ornare.

                    Praesent imperdiet magna pellentesque neque mattis, nec lobortis tellus euismod. Quisque at pretium tortor. Sed laoreet nibh leo, eu elementum ligula pretium eget. Fusce vel purus vitae ligula cursus ultrices. Donec auctor ipsum ac nisi eleifend, a suscipit nisi adipiscing. Sed semper justo et viverra adipiscing. Nulla consequat felis eu lectus ullamcorper, sit amet blandit tellus tempus. Nullam vel facilisis dui, ut tempor augue. Duis bibendum quis dolor a faucibus. Etiam id gravida augue. Vivamus diam purus, fringilla in tristique ut, accumsan vitae tortor. Curabitur a malesuada erat, ut placerat quam. Proin blandit lorem nec elementum suscipit. Sed sagittis, nibh a bibendum rhoncus, urna eros mollis est, quis ornare velit nulla sed tellus.";

            Assert.IsTrue(message.Length > 4000);
            logger.LogAsync(message).Wait();
        }
    }
}
