/* 
 * OpenBots Server API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = OpenBots.Service.API.Client.SwaggerDateConverter;

namespace OpenBots.Service.API.Model
{
    /// <summary>
    /// EmailVerification
    /// </summary>
    [DataContract]
        public partial class EmailVerification :  IEquatable<EmailVerification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailVerification" /> class.
        /// </summary>
        /// <param name="personId">personId (required).</param>
        /// <param name="address">address (required).</param>
        /// <param name="isVerified">isVerified (default to false).</param>
        /// <param name="verificationEmailCount">verificationEmailCount.</param>
        /// <param name="verificationCode">verificationCode.</param>
        /// <param name="verificationCodeExpiresOn">verificationCodeExpiresOn.</param>
        /// <param name="isVerificationEmailSent">isVerificationEmailSent (default to false).</param>
        /// <param name="verificationSentOn">verificationSentOn.</param>
        /// <param name="person">person.</param>
        /// <param name="id">id.</param>
        /// <param name="isDeleted">isDeleted (default to false).</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="deletedBy">deletedBy.</param>
        /// <param name="deleteOn">deleteOn.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="updatedBy">updatedBy.</param>
        public EmailVerification(Guid? personId = default(Guid?), string address = default(string), bool? isVerified = false, int? verificationEmailCount = default(int?), string verificationCode = default(string), DateTime? verificationCodeExpiresOn = default(DateTime?), bool? isVerificationEmailSent = false, DateTime? verificationSentOn = default(DateTime?), Person person = default(Person), Guid? id = default(Guid?), bool? isDeleted = false, string createdBy = default(string), DateTime? createdOn = default(DateTime?), string deletedBy = default(string), DateTime? deleteOn = default(DateTime?), byte[] timestamp = default(byte[]), DateTime? updatedOn = default(DateTime?), string updatedBy = default(string))
        {
            // to ensure "personId" is required (not null)
            if (personId == null)
            {
                throw new InvalidDataException("personId is a required property for EmailVerification and cannot be null");
            }
            else
            {
                this.PersonId = personId;
            }
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new InvalidDataException("address is a required property for EmailVerification and cannot be null");
            }
            else
            {
                this.Address = address;
            }
            // use default value if no "isVerified" provided
            if (isVerified == null)
            {
                this.IsVerified = false;
            }
            else
            {
                this.IsVerified = isVerified;
            }
            this.VerificationEmailCount = verificationEmailCount;
            this.VerificationCode = verificationCode;
            this.VerificationCodeExpiresOn = verificationCodeExpiresOn;
            // use default value if no "isVerificationEmailSent" provided
            if (isVerificationEmailSent == null)
            {
                this.IsVerificationEmailSent = false;
            }
            else
            {
                this.IsVerificationEmailSent = isVerificationEmailSent;
            }
            this.VerificationSentOn = verificationSentOn;
            this.Person = person;
            this.Id = id;
            // use default value if no "isDeleted" provided
            if (isDeleted == null)
            {
                this.IsDeleted = false;
            }
            else
            {
                this.IsDeleted = isDeleted;
            }
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.DeletedBy = deletedBy;
            this.DeleteOn = deleteOn;
            this.Timestamp = timestamp;
            this.UpdatedOn = updatedOn;
            this.UpdatedBy = updatedBy;
        }
        
        /// <summary>
        /// Gets or Sets PersonId
        /// </summary>
        [DataMember(Name="personId", EmitDefaultValue=false)]
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets IsVerified
        /// </summary>
        [DataMember(Name="isVerified", EmitDefaultValue=false)]
        public bool? IsVerified { get; set; }

        /// <summary>
        /// Gets or Sets VerificationEmailCount
        /// </summary>
        [DataMember(Name="verificationEmailCount", EmitDefaultValue=false)]
        public int? VerificationEmailCount { get; set; }

        /// <summary>
        /// Gets or Sets VerificationCode
        /// </summary>
        [DataMember(Name="verificationCode", EmitDefaultValue=false)]
        public string VerificationCode { get; set; }

        /// <summary>
        /// Gets or Sets VerificationCodeExpiresOn
        /// </summary>
        [DataMember(Name="verificationCodeExpiresOn", EmitDefaultValue=false)]
        public DateTime? VerificationCodeExpiresOn { get; set; }

        /// <summary>
        /// Gets or Sets IsVerificationEmailSent
        /// </summary>
        [DataMember(Name="isVerificationEmailSent", EmitDefaultValue=false)]
        public bool? IsVerificationEmailSent { get; set; }

        /// <summary>
        /// Gets or Sets VerificationSentOn
        /// </summary>
        [DataMember(Name="verificationSentOn", EmitDefaultValue=false)]
        public DateTime? VerificationSentOn { get; set; }

        /// <summary>
        /// Gets or Sets Person
        /// </summary>
        [DataMember(Name="person", EmitDefaultValue=false)]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets IsDeleted
        /// </summary>
        [DataMember(Name="isDeleted", EmitDefaultValue=false)]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name="createdOn", EmitDefaultValue=false)]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets DeletedBy
        /// </summary>
        [DataMember(Name="deletedBy", EmitDefaultValue=false)]
        public string DeletedBy { get; set; }

        /// <summary>
        /// Gets or Sets DeleteOn
        /// </summary>
        [DataMember(Name="deleteOn", EmitDefaultValue=false)]
        public DateTime? DeleteOn { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public byte[] Timestamp { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedOn
        /// </summary>
        [DataMember(Name="updatedOn", EmitDefaultValue=false)]
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailVerification {\n");
            sb.Append("  PersonId: ").Append(PersonId).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  IsVerified: ").Append(IsVerified).Append("\n");
            sb.Append("  VerificationEmailCount: ").Append(VerificationEmailCount).Append("\n");
            sb.Append("  VerificationCode: ").Append(VerificationCode).Append("\n");
            sb.Append("  VerificationCodeExpiresOn: ").Append(VerificationCodeExpiresOn).Append("\n");
            sb.Append("  IsVerificationEmailSent: ").Append(IsVerificationEmailSent).Append("\n");
            sb.Append("  VerificationSentOn: ").Append(VerificationSentOn).Append("\n");
            sb.Append("  Person: ").Append(Person).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsDeleted: ").Append(IsDeleted).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  DeletedBy: ").Append(DeletedBy).Append("\n");
            sb.Append("  DeleteOn: ").Append(DeleteOn).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  UpdatedOn: ").Append(UpdatedOn).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EmailVerification);
        }

        /// <summary>
        /// Returns true if EmailVerification instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailVerification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailVerification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PersonId == input.PersonId ||
                    (this.PersonId != null &&
                    this.PersonId.Equals(input.PersonId))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.IsVerified == input.IsVerified ||
                    (this.IsVerified != null &&
                    this.IsVerified.Equals(input.IsVerified))
                ) && 
                (
                    this.VerificationEmailCount == input.VerificationEmailCount ||
                    (this.VerificationEmailCount != null &&
                    this.VerificationEmailCount.Equals(input.VerificationEmailCount))
                ) && 
                (
                    this.VerificationCode == input.VerificationCode ||
                    (this.VerificationCode != null &&
                    this.VerificationCode.Equals(input.VerificationCode))
                ) && 
                (
                    this.VerificationCodeExpiresOn == input.VerificationCodeExpiresOn ||
                    (this.VerificationCodeExpiresOn != null &&
                    this.VerificationCodeExpiresOn.Equals(input.VerificationCodeExpiresOn))
                ) && 
                (
                    this.IsVerificationEmailSent == input.IsVerificationEmailSent ||
                    (this.IsVerificationEmailSent != null &&
                    this.IsVerificationEmailSent.Equals(input.IsVerificationEmailSent))
                ) && 
                (
                    this.VerificationSentOn == input.VerificationSentOn ||
                    (this.VerificationSentOn != null &&
                    this.VerificationSentOn.Equals(input.VerificationSentOn))
                ) && 
                (
                    this.Person == input.Person ||
                    (this.Person != null &&
                    this.Person.Equals(input.Person))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.IsDeleted == input.IsDeleted ||
                    (this.IsDeleted != null &&
                    this.IsDeleted.Equals(input.IsDeleted))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.CreatedOn == input.CreatedOn ||
                    (this.CreatedOn != null &&
                    this.CreatedOn.Equals(input.CreatedOn))
                ) && 
                (
                    this.DeletedBy == input.DeletedBy ||
                    (this.DeletedBy != null &&
                    this.DeletedBy.Equals(input.DeletedBy))
                ) && 
                (
                    this.DeleteOn == input.DeleteOn ||
                    (this.DeleteOn != null &&
                    this.DeleteOn.Equals(input.DeleteOn))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.UpdatedOn == input.UpdatedOn ||
                    (this.UpdatedOn != null &&
                    this.UpdatedOn.Equals(input.UpdatedOn))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.PersonId != null)
                    hashCode = hashCode * 59 + this.PersonId.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.IsVerified != null)
                    hashCode = hashCode * 59 + this.IsVerified.GetHashCode();
                if (this.VerificationEmailCount != null)
                    hashCode = hashCode * 59 + this.VerificationEmailCount.GetHashCode();
                if (this.VerificationCode != null)
                    hashCode = hashCode * 59 + this.VerificationCode.GetHashCode();
                if (this.VerificationCodeExpiresOn != null)
                    hashCode = hashCode * 59 + this.VerificationCodeExpiresOn.GetHashCode();
                if (this.IsVerificationEmailSent != null)
                    hashCode = hashCode * 59 + this.IsVerificationEmailSent.GetHashCode();
                if (this.VerificationSentOn != null)
                    hashCode = hashCode * 59 + this.VerificationSentOn.GetHashCode();
                if (this.Person != null)
                    hashCode = hashCode * 59 + this.Person.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.IsDeleted != null)
                    hashCode = hashCode * 59 + this.IsDeleted.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.DeletedBy != null)
                    hashCode = hashCode * 59 + this.DeletedBy.GetHashCode();
                if (this.DeleteOn != null)
                    hashCode = hashCode * 59 + this.DeleteOn.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
