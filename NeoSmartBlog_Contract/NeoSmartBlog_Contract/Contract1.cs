using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace NeoSmartBlog_Contract
{
    public class Contract1 : Neo.SmartContract.Framework.SmartContract
    {
        public static bool Main(byte[] sign,byte[] pubkey,byte[] key,byte[] value)
        {
            //verifySign
            bool b=SmartContract.VerifySignature(sign, pubkey);
            if (b == false) return false;

            //write it
            var hashkey = Helper.AsString(SmartContract.Hash160(pubkey));

            var _key = hashkey + "." + Helper.AsString(key);
            Storage.Put(Storage.CurrentContext, Helper.AsByteArray(_key), value);

            //write last
            var last = hashkey + "_last";
            var now = hashkey + "_now";
            var lastid = Storage.Get(Storage.CurrentContext, Helper.AsByteArray(now));
            var nowid = Blockchain.GetHeight();
            Storage.Put(Storage.CurrentContext, Helper.AsByteArray(now), nowid);
            Storage.Put(Storage.CurrentContext, Helper.AsByteArray(last), lastid);
            return true;
        }
    }
}
